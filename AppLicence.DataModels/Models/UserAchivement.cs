using System;
using System.Collections.Generic;

namespace AppLicence.DataModels.Models;

public partial class UserAchivement
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long AchivementId { get; set; }

    public virtual Achivement Achivement { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
