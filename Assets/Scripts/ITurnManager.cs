using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface ITurnManager {
    Character NextCharacter();
    void Renew();
}
