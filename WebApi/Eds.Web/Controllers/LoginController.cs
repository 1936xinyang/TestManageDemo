using Eds.Common.Models;
using log4net;
using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Eds.Web.Controllers
{
    public class LoginController : Controller
    {
        private ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.Assembly, MethodBase.GetCurrentMethod().DeclaringType);
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
        //public RedirectResult Login()
        //{
        //    string strRedirectUri = "";
        //    string strLoginName = "";
        //    OnLogin(strLoginName);
        //    return new RedirectResult(strRedirectUri);
        //}
        protected void OnLogin(string strLoginName)
        {
            //TODO: 初始化用户基本信息
        }

        public ActionResult GetValidateCode()
        {
            string code = CreateValidateCode(4);
            Session["ValidateCode"] = code;
            byte[] bytes = CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
        public string GetLogin()
        {
            string msg = "";
            string userCode = HttpContext.Request.Params["userCode"].ToString();
            string password = HttpContext.Request.Params["password"].ToString();
            string inputCheckCode = HttpContext.Request.Params["inputCheckCode"].ToString();
            string code = (string)Session["ValidateCode"];
            if (code != inputCheckCode)
            {
                msg = "001";
            }
            else
            {
                msg = GetLoginInfo(userCode, password);
            }

            return msg;
        }


        public string GetLoginUserName()
        {
            if (Session["SK_LOGININFO"] != null)
            {
                return ((LoginInfo)Session["SK_LOGININFO"]).UserName + "|" + ((LoginInfo)Session["SK_LOGININFO"]).RoleName;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public string LoginOut()
        {
            //if (Session["ServerSessionId"] != null)
            //{
            //    var authorizationAppId = Guid.Parse(ConfigurationSettings.AppSettings["AuthorizationAppId"]);
            //    var ssoService = new SSOAuthorizationAPI.SSOAuthorizationClient();
            //    var LoginOffInfo = ssoService.LoginOff(new SSOAuthorizationAPI.UserLoginOffModel { AuthorizationAppId = authorizationAppId, Browser = "IE/8", SessionId = Session["ServerSessionId"].ToString() });
            //    if (LoginOffInfo.IsLoginOff)
            //    {
            //        Session["SK_LOGININFO"] = null;
            //        Session["ServerSessionId"] = null;
            //        return "";
            //    }
            //    else
            //    {
                    return "100";
            //    }
            //}
            //else
            //{

            //    Session["SK_LOGININFO"] = null;
            //    return "";
            //}
            

        }
        //// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="length">指定验证码的长度</param>
        /// <returns></returns>
        public string CreateValidateCode(int length)
        {
            int[] randMembers = new int[length];
            int[] validateNums = new int[length];
            string validateNumberStr = "";
            //生成起始序列值
            int seekSeek = unchecked((int)DateTime.Now.Ticks);
            Random seekRand = new Random(seekSeek);
            int beginSeek = (int)seekRand.Next(0, Int32.MaxValue - length * 10000);
            int[] seeks = new int[length];
            for (int i = 0; i < length; i++)
            {
                beginSeek += 10000;
                seeks[i] = beginSeek;
            }
            //生成随机数字
            for (int i = 0; i < length; i++)
            {
                Random rand = new Random(seeks[i]);
                int pownum = 1 * (int)Math.Pow(10, length);
                randMembers[i] = rand.Next(pownum, Int32.MaxValue);
            }
            //抽取随机数字
            for (int i = 0; i < length; i++)
            {
                string numStr = randMembers[i].ToString();
                int numLength = numStr.Length;
                Random rand = new Random();
                int numPosition = rand.Next(0, numLength - 1);
                validateNums[i] = Int32.Parse(numStr.Substring(numPosition, 1));
            }
            //生成验证码
            for (int i = 0; i < length; i++)
            {
                validateNumberStr += validateNums[i].ToString();
            }
            return validateNumberStr;
        }

        /// <summary>
        /// 创建验证码的图片
        /// </summary>
        /// <param name="containsPage">要输出到的page对象</param>
        /// <param name="validateNum">验证码</param>
        public byte[] CreateValidateGraphic(string validateCode)
        {
            Bitmap image = new Bitmap((int)Math.Ceiling(validateCode.Length * 20.0), 32);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();
                //清空图片背景色
                g.Clear(Color.White);
                //画图片的干扰线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                Font font = new Font("Arial", 22, (FontStyle.Bold | FontStyle.Italic));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
                 Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateCode, font, brush, 3, 2);
                //画图片的前景干扰点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                //保存图片数据
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                //输出图片流
                return stream.ToArray();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

        /// <summary>
        /// 调用统一认证接口系统获取用户登陆信息
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string GetLoginInfo(string userCode, string password)
        {

            //string msg = "";
            //var authorizationAppId = Guid.Parse(ConfigurationSettings.AppSettings["AuthorizationAppId"]);
            //var ssoService = new SSOAuthorizationAPI.SSOAuthorizationClient();
            //var Autherization = new AutherizationQueryAPI.ForeignApiContractClient();
            //SSOAuthorizationAPI.UserLoginResultModel loginInfo = null;
            //if (string.Compare(password, userCode + "@123", true) == 0)
            //{
            //    loginInfo = new SSOAuthorizationAPI.UserLoginResultModel();
            //    loginInfo.ErroCode = SSOAuthorizationAPI.ErrorCode.ServerSuccess;
            //    loginInfo.UserName = userCode;
            //    loginInfo.SessionId = Guid.NewGuid().ToString();
            //}
            //else
            //{
            //    loginInfo = ssoService.Login(new SSOAuthorizationAPI.UserLoginModel
            //    {
            //        UserName = userCode,
            //        Password = password,
            //        AuthorizationAppId = authorizationAppId,
            //        Browser = "IE/8",
            //    });
            //}
            //if (loginInfo.ErroCode == SSOAuthorizationAPI.ErrorCode.ServerSuccess)
            //{
            //    try
            //    {
            //        LoginInfo LoginInfoModel = new LoginInfo();
            //        LoginInfoModel.UserId = loginInfo.UserName;
            //        LoginInfoModel.UserName = Autherization.GetUserInfo(loginInfo.UserName).UserFullName;
            //        AutherizationQueryAPI.AuthRoleDTO[] authRoleDTO = Autherization.GetAuthRole(loginInfo.UserName, authorizationAppId).Results;
            //        LoginInfoModel.RoleId = authRoleDTO[0].Id.ToString();
            //        LoginInfoModel.RoleName = authRoleDTO[0].Name.ToString();
            //        Session.Timeout = Convert.ToInt32(ConfigurationSettings.AppSettings["SessionTimeout"]);
            //        Session["SK_LOGININFO"] = LoginInfoModel;
            //        Session["ServerSessionId"] = loginInfo.SessionId;
            //    }
            //    catch (Exception ex)
            //    {
            //        log.Error(string.Format("查询账户[{0}]登录权限失败：{1}", loginInfo.UserName, ex.Message));
            //        log.Error(ex.StackTrace);
            //        return "101";
            //    }
            //}
            //return ((int)loginInfo.ErroCode).ToString();
            return null;
        }


        public void AddLoginLog(string UserId, string UserName, string RoleId, string RoleName, string ServerSessionId, string Ip)
        {
            //LoginLogDataMgr loginLogDataMgr = new LoginLogDataMgr();
            LoginLog LoginLogModel = new LoginLog();
            LoginLogModel.LoginLogId = DateTime.Now.ToString("yyyymmddhhmmssss");
            LoginLogModel.RoleId = RoleId;
            LoginLogModel.RoleName = RoleName;
            LoginLogModel.UserId = UserId;
            LoginLogModel.UserName = UserName;
            LoginLogModel.ServerSessionId = ServerSessionId;
            LoginLogModel.IP = Ip;
            LoginLogModel.CreateDate = DateTime.Now;
            LoginLogModel.CreateMan = "System";
            LoginLogModel.UpdateDate = DateTime.Now;
            LoginLogModel.UpdateMan = "System";
            //loginLogDataMgr.InsertModle(LoginLogModel);
        }
    }


    public class UserMenu
    {
        public string MenuId { get; set; }
        public string MenuName { get; set; }
    }
}