using MarsRover.Model;
using MarsRover.Utilities.Results;


namespace MarsRover.Services
{
    public  interface IPosition
    {
        IDataResult<Direction> LValue(Direction L);
        IDataResult<Direction> RValue(Direction R);
        IDataResult<Cordinate> MValue(Cordinate cordinate);
        IResult Start(Cordinate cordinate, string startValue);
        
    }
}
