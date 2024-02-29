using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestaoCinco.Application.Lancamentos.Commands
{
    public class LancamentoUpdateCommand : LancamentoCommand
    {
        public string LancamentoId { get; set; }
    }
}
