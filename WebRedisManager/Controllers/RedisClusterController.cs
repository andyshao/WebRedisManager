﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SAEA.RedisSocket.Model;
using WebRedisManager.Libs;
using WebRedisManager.Models;

namespace WebRedisManager.Controllers
{
    /// <summary>
    /// Redis cluster controller
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class RedisClusterController : Controller
    {
        /// <summary>
        /// 获取cluster 节点信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult GetClusterNodes(string name)
        {
            try
            {
                List<ClusterNode> result = new List<ClusterNode>();

                if (CurrentRedisClient.IsCluster(name))
                {
                    result = CurrentRedisClient.GetClusterNodes(name);
                }               

                return Json(new JsonResult<List<ClusterNode>>() { Code = 1, Data = result, Message = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new JsonResult<string>() { Code = 2, Message = ex.Message });
            }
        }
    }
}
