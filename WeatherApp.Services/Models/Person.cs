using System.Threading;

namespace WeatherApp.Services.Models;

//state model https://www.dofactory.com/net/state-design-pattern
//context = Person
//state = clothes has a Person obj
//state manages everything - person has a BodyTempType but it just returns the state's value

public abstract class State
{
    protected Person _person;
    protected Clothes _clothes;

    public Person Person
    {
        get { return _person; }
        set { _person = value; }
    }

    public Clothes Clothes
    {
        get { return _clothes; }
        set { _clothes = value; }
    }

    public abstract void SetWeather(WeatherModel weather);
    public abstract void SetActivity(int activityLevel);
    public abstract void SetBodyTempType(int bodyTempType);

}

//confused....

public class NormalState : State
{
    private int _offSet;
    public NormalState(State state)
    {
        this._person = state.Person;
        this._clothes = state.Clothes;
        Initialize();
    }

    private void Initialize()
    {
        this._offSet = 0;
    }

    private void StateChangeCheck()
    {
        //
    }

    public override void SetActivity(int activityLevel) => throw new System.NotImplementedException();
    public override void SetBodyTempType(int bodyTempType) => throw new System.NotImplementedException();
    public override void SetWeather(WeatherModel weather) => throw new System.NotImplementedException();
}

public class Person
{
    private State _state;
    public Clothes Clothes { get; set; } //clothes depends on Weather, Activity, Type Of Person
    public string Location { get; set; }
    public int BodyTempType { get; set; } //0 = cold - 10 hot
    public int ActivityLevel { get; set; } //0= low - 10 playing hockey

    public Person()
    {

    }

}