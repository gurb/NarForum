using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public string SGuid { get; set; } = Guid.NewGuid().ToString(); 
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public bool IsActive { get; set; } = true;
}
