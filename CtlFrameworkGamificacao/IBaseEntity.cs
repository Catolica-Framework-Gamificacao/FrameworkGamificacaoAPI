using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkGamificacaoClasses
{
	public interface IBaseEntity
	{
		public long ID { get; set; }
		public DateTime DateCreation { get; set; }
		public DateTime DateUpdate { get; set; }
	}
}
