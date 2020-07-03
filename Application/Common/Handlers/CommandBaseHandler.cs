using Application.Common.Interfaces;

namespace Application.Common.Handlers
{
    public abstract class CommandBaseHandler
    {
        protected readonly IApplicationContext context;

        public CommandBaseHandler(IApplicationContext context)
        {
            this.context = context;
        }
    }
}
