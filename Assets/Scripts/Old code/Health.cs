 

public class Health  
{
	private int maxHealth;
	private int _points;
    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
        private set { maxHealth = value; }
    }
	public int points
	{
		get {
			return _points;
		}
		set{
			_points = value;
			if (_points < 0)
				_points = 0;
			if (_points > maxHealth)
				_points = maxHealth;
		}
	}
 public Health(int maxHealth)
	{
		this.maxHealth = maxHealth;
		_points = this.maxHealth;
	}
}
