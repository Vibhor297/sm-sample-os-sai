using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sample.Repository.Models;
using Sample.Services;
using sample_poc_sai_proj.Static;

namespace sample_poc_sai_proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyncController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IActionResult>> CheckAndUpdate()
        {
            try
            {
                await Execute();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }


        private static async Task Execute()
        {
            using (StudentService studentService = new StudentService())
            {
                List<SepsdChangedStudent> changedStudents = await studentService.GetChangedStudents();

                //List<SepsdStudent> students = await studentService.LoadStudent(new SepsdChangedStudent());

                //var studentJson = JsonConvert.SerializeObject(students);

                //PutItemResponse response = await Common.putItemAsync(client, "447571773", "", studentJson);

                //Console.WriteLine(response.HttpStatusCode);

                //if (changedStudents.Count > 0)
                //{
                //    using (AmazonDynamoDBClient client = Common.GetDynamodbClient())
                //    {
                //        if (client != null)
                //        {
                //            TaskFactory taskFactory = new TaskFactory();
                //            //get students from ern
                //            foreach (var studentChanged in changedStudents)
                //            {
                //                var response = await taskFactory.StartNew(async () =>
                //                {
                //                    List<SepsdStudent> students = await studentService.LoadStudent(studentChanged);

                //                    var studentJson = JsonConvert.SerializeObject(students);

                //                    await Common.putItemAsync(client, studentChanged.StudentRecordNo.ToString(), "Student_Entity", studentJson);

                //                });
                //                Task.WaitAll(response);                                
                //            }
                //        }
                //        else
                //            Console.WriteLine("Error in creating AWS dynamo db session");
                //    }
                //}

                try
                {
                    using (AmazonDynamoDBClient client = Common.GetDynamodbClient())
                    {
                        TaskFactory taskFactory = new TaskFactory();
                        //get students from ern

                        var response = await taskFactory.StartNew(async () =>
                        {
                            List<SepsdStudent> students = await studentService.LoadStudent(new SepsdChangedStudent());

                            var studentJson = JsonConvert.SerializeObject(students);

                            await Common.putItemAsync(client, "447571773", "Student_Entity", studentJson);

                        });
                        Task.WaitAll(response);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
