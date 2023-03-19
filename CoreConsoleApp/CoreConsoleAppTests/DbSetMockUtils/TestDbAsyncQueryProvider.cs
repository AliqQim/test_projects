using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleAppTests.DbSetMockUtils
{
    //https://stackoverflow.com/a/43594599 with little changes to satisfy compiler
    public class AsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        public AsyncEnumerable(Expression expression)
            : base(expression) { }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            => new AsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        
    }

    public class AsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> enumerator;

        public AsyncEnumerator(IEnumerator<T> enumerator) =>
            this.enumerator = enumerator ?? throw new ArgumentNullException();

        public T Current => enumerator.Current;


        public ValueTask DisposeAsync() => ValueTask.CompletedTask;
        

        public ValueTask<bool> MoveNextAsync()
            => ValueTask.FromResult(enumerator.MoveNext());
    }
}
