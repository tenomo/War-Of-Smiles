//using UnityEngine;

public class DualTimer  
{
	private System.Timers.Timer External;
    private System.Timers.Timer Nested;
    private short CountIterationsNested;   
    private int MaxcountIterationsNestedTimer; 
    private short NestedTInterval_min;
    private short NestedTInterval_max;     

    public double ExternalTimerInterval
    {
        
        get
        {
            if (this.External != null)
            {
                return this.External.Interval;
            }
            else
            {
                UnityEngine.Debug.LogError("ExternalTimer not initialized");
                return 0;
            }
        }

        set
        {
            if (this.External != null)
            {
                if (value <= 10000)
                    this.External.Interval = value;
                else UnityEngine.Debug.LogError("value should not be less than 10 or greater than 10 000 milliseconds");
            }
            else
            {
                UnityEngine.Debug.LogError("ExternalTimer not initialized");
            }

        }
    }
 

    public delegate void PointerMethod();
    private PointerMethod methodPerformedInNested;

    public PointerMethod MethodPerformedInNested
    {
      private  get { return this.methodPerformedInNested; }
        set
        {
            this.methodPerformedInNested = value;
        }
    }

    private PointerMethod methodPerformedInExternal;

    public PointerMethod MethodPerformedInExternal
    {
        private get { return this.methodPerformedInExternal; }
        set
        {
            this.methodPerformedInExternal = value;
        }
    }

    public DualTimer(PointerMethod executingMethod, short ExternalTimerInterval, short NTIntervalMin, short NTIntervalMax, int countIterationsNestedTimer)
    { 
        this.methodPerformedInNested = executingMethod;
        this.MaxcountIterationsNestedTimer = countIterationsNestedTimer;
        this.NestedTInterval_max = NTIntervalMax;
        this.NestedTInterval_min = NTIntervalMin;

        this.initExternalTimer(ExternalTimerInterval);
        this.initializationNestedTimerTimer();
    }

    void initExternalTimer(int interval)
    {
        this.External = new System.Timers.Timer();
        this.External.Interval = 2000;
        this.External.Elapsed += this.ExternalTimer_Elapsed;

    }

    void initializationNestedTimerTimer()
    {
        Nested = new System.Timers.Timer();
        Nested.Interval = 1;
        Nested.Elapsed += NestedTimer_Elapsed;
        CountIterationsNested = 0;
    }

     
    void ExternalTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    { 
        if (this.MethodPerformedInExternal != null)
            this.MethodPerformedInExternal();
        CountIterationsNested = 0; 
        this.External.Stop();
        this.Nested.Interval = this.RandomInterval(this.NestedTInterval_min, this.NestedTInterval_max);
        this.Nested.Start();

    } 

    void NestedTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        if (this.CountIterationsNested < this.MaxcountIterationsNestedTimer)
        {
            if (this.methodPerformedInNested != null)
                this.methodPerformedInNested();
            this.CountIterationsNested++;             
            this.Nested.Interval = this.RandomInterval(this.NestedTInterval_min, this.NestedTInterval_max);            
            Nested.Start();            
        }
        else
        {
            this.Nested.Stop();
            this.External.Start();
        }

    }
    private int RandomInterval(int minValue, int maxValue)
    {
        System.Random randObgj = new System.Random();
        return randObgj.Next(minValue, maxValue);
    }

    public void StartTimer()
    {
        this.External.Start();
    }

    public void StopTimer()
    {
        this.External.Stop();
        this.Nested.Stop();
    }

    public void NestedTimeDiapason(short NTIntervalMin, short NTIntervalMax)
    {
        this.NestedTInterval_max = NTIntervalMax;
        this.NestedTInterval_min = NTIntervalMin;
    }

}

