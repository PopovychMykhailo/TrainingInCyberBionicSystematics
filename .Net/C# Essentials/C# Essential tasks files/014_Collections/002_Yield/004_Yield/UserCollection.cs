using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System;

namespace Yield
{
    class UserCollection
    {
        public static IEnumerable Power()
        {
            return new ClassPower(-2);
        }

        private sealed class ClassPower : IEnumerable<object>, IEnumerable, IEnumerator<object>, IEnumerator, IDisposable
        {
            // Поля.
            private int state1;
            private object current2;
            private int initialThreadId_1;

            // Конструктор.
            public ClassPower(int state1)
            {
                this.state1 = state1;
                this.initialThreadId_1 = Thread.CurrentThread.ManagedThreadId;
            }

            //private bool IEnumerator.MoveNext() // Так в Рефлекторе.
            bool IEnumerator.MoveNext()
            {
                if (this.state1 == 0)
                {
                    this.state1 = -1;
                }
                return false;
            }

            IEnumerator<object> IEnumerable<object>.GetEnumerator()
            {
                if ((Thread.CurrentThread.ManagedThreadId == this.initialThreadId_1) && (this.state1 == -2))
                {
                    this.state1 = 0;
                    return this;
                }
                return new UserCollection.ClassPower(0);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return (this as IEnumerable<object>).GetEnumerator();
            }

            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            void IDisposable.Dispose()
            {
            }

            // Свойства.
            object IEnumerator<object>.Current
            {
                get
                {
                    return this.current2;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return this.current2;
                }
            }
        }
    }
}
