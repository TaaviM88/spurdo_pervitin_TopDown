using System.Collections;
using System.Collections.Generic;

public interface ITakeDamage<T>
{
    void Damage(T damageTaken);
}

public interface IDie
{
    void Die();
}
