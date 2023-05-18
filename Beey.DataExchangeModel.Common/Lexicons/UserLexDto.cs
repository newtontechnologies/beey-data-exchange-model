using System;
using System.Collections.Generic;
using System.Text;

namespace Beey.DataExchangeModel.Lexicons;

public class UserLexDto : EntityDtoBase
{
    public int TeamId { get; set; }
    public string? Language { get; set; }
    public string? Lexicon { get; set; }
}
