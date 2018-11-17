using System;

namespace flarebattleship
{
    interface IValidation
    {
        bool Validate(out string message);
    }
}