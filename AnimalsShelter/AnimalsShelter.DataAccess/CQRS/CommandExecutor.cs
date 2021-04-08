using AnimalsShelter.DataAccess.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly AnimalsShelterStorageContext _context;

        public CommandExecutor(AnimalsShelterStorageContext context)
        {
            _context = context;
        }

        public Task<TResult> Executor<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(_context);
        }
    }
}
