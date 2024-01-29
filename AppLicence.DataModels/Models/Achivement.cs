using System;
using System.Collections.Generic;

namespace AppLicence.DataModels.Models;

public partial class Achivement
{
    public long Id { get; set; }

    public long Name { get; set; }

    public long Descripton { get; set; }

    public virtual ICollection<UserAchivement> UserAchivements { get; set; } = new List<UserAchivement>();
}
