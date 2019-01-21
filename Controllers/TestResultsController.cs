using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dev.Model;
using dev.Service;

namespace dev.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestResultsController : ControllerBase
    {
        private readonly ITestResultsService _testResultsService;

        public TestResultsController(ITestResultsService testResultsService)
        {
            _testResultsService = testResultsService;
        }

        [HttpGet]
        public async Task<IEnumerable<TestResult>> GetResults()
        {
            return await _testResultsService.GetTestResultsAsync();
        }

        [Route("~/api/[controller]/{id}")]
        [HttpGet]
        public async Task<TestResult> GetResult(long id)
        {
            return await _testResultsService.GetTestResultAsync(id);
        }

        [HttpPost]
        public async Task<TestResult> Create(TestResult result)
        {
            return await _testResultsService.AddTestResultAsync(result);
        }

        [HttpPut]
        public async Task<TestResult> Update(TestResult result)
        {
            return await _testResultsService.UpdateTestResultAsync(result);
        }

        [Route("~/api/[controller]/{id}")]
        [HttpDelete]
        public async Task<long> Delete(long id)
        {
            return await _testResultsService.DeleteTestResultAsync(id);
        }
    }
}