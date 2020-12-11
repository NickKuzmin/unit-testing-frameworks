using System;
using System.Threading.Tasks;
using Xunit;

public class AsyncExamples
{
    /// <summary>
    /// Assert.ThrowsAsync
    /// Record.ExceptionAsync
    /// </summary>

    [Fact]
    public async void CodeThrowsAsync()
    {
        Func<Task> testCode = () => Task.Factory.StartNew(ThrowingNotImplementedExceptionMethod);

        var ex = await Assert.ThrowsAsync<NotImplementedException>(testCode);

        Assert.IsType<NotImplementedException>(ex);
    }

    [Fact]
    public async void CodeThrowsAsync2()
    {
        Func<Task> testCode = () => Task.Factory.StartNew(ThrowingExceptionMethod);

        var ex = await Assert.ThrowsAnyAsync<Exception>(testCode);

        Assert.IsNotType<NotImplementedException>(ex);
    }

    [Fact]
    public async void CodeThrowsAsync3()
    {
        Func<Task> testCode = () => Task.Factory.StartNew(ThrowingExceptionMethod);

        var ex = await Assert.ThrowsAsync(typeof(Exception), testCode);

        Assert.IsNotType<NotImplementedException>(ex);
    }

    [Fact]
    public async void RecordAsync()
    {
        Func<Task> testCode = () => Task.Factory.StartNew(ThrowingNotImplementedExceptionMethod);

        var ex = await Record.ExceptionAsync(testCode);

        Assert.IsType<NotImplementedException>(ex);
    }

    [Fact]
    public async void RecordAsync2()
    {
        Func<Task> testCode = () => Task.Factory.StartNew(ThrowingExceptionMethod);

        var ex = await Record.ExceptionAsync(testCode);

        Assert.IsType<Exception>(ex);
    }

    void ThrowingNotImplementedExceptionMethod()
    {
        throw new NotImplementedException();
    }

    void ThrowingExceptionMethod()
    {
        throw new Exception();
    }
}

