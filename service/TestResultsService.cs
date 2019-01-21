using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dev.Model;
using dev.Repositories;

namespace dev.Service
{
    public interface ITestResultsService
    {
        Task<IEnumerable<TestResult>> GetTestResultsAsync();
        Task<TestResult> GetTestResultAsync(long testResultId);
        Task<TestResult> AddTestResultAsync(TestResult testResult);
        Task<TestResult> UpdateTestResultAsync(TestResult testResult);
        Task<long> DeleteTestResultAsync(long testResultId);
    }

    public class TestResultsService : ITestResultsService
    {
        private ITestResultsRepository _repoistory;

        public TestResultsService(ITestResultsRepository repository)
        {
            _repoistory = repository;
        }

        public Task<TestResult> AddTestResultAsync(TestResult testResult)
        {
            return _repoistory.AddTestResultAsync(testResult);
        }

        public Task<long> DeleteTestResultAsync(long testResultId)
        {
            return _repoistory.DeleteTestResultAsync(testResultId);
        }

        public Task<TestResult> GetTestResultAsync(long testResultId)
        {
            return _repoistory.GetTestResultAsync(testResultId);
        }

        public Task<IEnumerable<TestResult>> GetTestResultsAsync()
        {
            return _repoistory.GetTestResultsAsync();
        }

        public Task<TestResult> UpdateTestResultAsync(TestResult testResult)
        {
            return _repoistory.UpdateTestResultAsync(testResult);
        }
    }
}