using AnimalsShelter.DataAccess.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.DataAccess.CQRS
{
    public interface ICommandExecutor
    {
        Task<TResult> Executor<TParameters, TResult>(CommandBase<TParameters, TResult> command);
    }
}
