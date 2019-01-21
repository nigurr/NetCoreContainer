using dev.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace dev.Repositories
{
    public interface ITestResultsRepository
    {
        Task<IEnumerable<TestResult>> GetTestResultsAsync();
        Task<TestResult> GetTestResultAsync(long testResultId);
        Task<TestResult> AddTestResultAsync(TestResult testResult);
        Task<TestResult> UpdateTestResultAsync(TestResult testResult);
        Task<long> DeleteTestResultAsync(long testResultId);
    }

    public class TestResultsRepository : ITestResultsRepository
    {
        private readonly TestResultsDbContext _context;

        public TestResultsRepository(TestResultsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TestResult>> GetTestResultsAsync()
        {
            return await _context.TestResults.ToListAsync();
        }

        public async Task<TestResult> GetTestResultAsync(long testResultId)
        {
            return await _context.TestResults.FindAsync(testResultId);
        }

        public async Task<TestResult> UpdateTestResultAsync(TestResult testResult)
        {
            var exist = await _context.TestResults.FindAsync(testResult.Id);
            if (exist != null)
            {
                var createdData = exist.Created;
                testResult.Created = createdData;
                _context.Entry(exist).CurrentValues.SetValues(testResult);
                
                await _context.SaveChangesAsync();
            }
            return exist;
        }

        public async Task<TestResult> AddTestResultAsync(TestResult testResult)
        {
            _context.TestResults.Add(testResult);
            await _context.SaveChangesAsync();
            return testResult;
        }

        public async Task<long> DeleteTestResultAsync(long testResultId)
        {
            var exist = await _context.TestResults.FindAsync(testResultId);
            if (exist != null)
            {
                _context.TestResults.Remove(exist);
                return await _context.SaveChangesAsync();
            }
            return testResultId;
        }
    }
}