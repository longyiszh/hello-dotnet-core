using System;
using EmberMug.Lib;
using EmberMug.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmberMug.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmugTestController : ControllerBase
    {

        [HttpGet]
        public CommonMessage SeeTheSLList()
        {
            var message = new CommonMessage()
            {
                OK = true,
                Message = "",
            };

            var list = new SinglyLinkedList<string>();
            list.Add("C'est");
            list.Add("la");
            list.Add("vie");

            //foreach (var node in list)
            //{
            //    message.Message += $"{node.Data} -> ";
            //}

            // message.Message += "(end)";


            list.Remove(list.Head);
            list.Remove(list.Tail);
            list.Remove(list.Head);


            message.Message = string.Join(" -> ", list);

            return message;


        }
    }

}