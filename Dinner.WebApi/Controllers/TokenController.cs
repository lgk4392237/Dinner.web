using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dinner.Common;
using Dinner.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dinner.WebApi.Controllers
{
    /// <summary>
    /// 获取令牌
    /// </summary>
    public class TokenController : Controller
    {
        /// <summary>
        /// 登录获取令牌
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login(string userName)
        {
            string jwtStr = string.Empty;
            bool suc = false;
            if (!string.IsNullOrEmpty(userName))
            {
                TokenModel tokenModel = new TokenModel { Uid = "abcd", Role = userName };
                jwtStr = JwtHelper.IssueJwt(tokenModel);
                suc = true;
            }
            else
            {
                jwtStr = "登录错误";
            }
            return Ok(new { success = suc, token = jwtStr });
        }
    }
}
