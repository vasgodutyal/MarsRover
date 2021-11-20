using MarsRover.Model;
using MarsRover.Utilities.Results;
using System;

namespace MarsRover.Services
{
    public class Position : IPosition
    {
        public IDataResult<Direction> LValue(Direction L)
        {
            if (L== Direction.N)
                return  new SuccessDataResult<Direction>(Direction.W);

            else if (L == Direction.W)
                return new SuccessDataResult<Direction>(Direction.S);

            else if (L == Direction.S)
                return new SuccessDataResult<Direction>(Direction.E);

            else if (L == Direction.E)
                return new SuccessDataResult<Direction>(Direction.N);

            else
                return new ErrorDataResult<Direction>(message:"Hatalı Karakter");

        }

        public IDataResult<Direction> RValue(Direction R)
        {
            if (R == Direction.N)
                return new SuccessDataResult<Direction>(Direction.E);

            else if (R == Direction.E)
                return new SuccessDataResult<Direction>(Direction.S);

            else if (R == Direction.S)
                return new SuccessDataResult<Direction>(Direction.W);

            else if (R == Direction.W)
                return new SuccessDataResult<Direction>(Direction.N);

            else
                return new ErrorDataResult<Direction>(message: "Hatalı Karakter");

        }

        public IDataResult<Cordinate> MValue(Cordinate cordinate)
        {
            if (cordinate.state.ToString() == "N")
                cordinate.yValue++;

            else if (cordinate.state.ToString() == "W")
                cordinate.xValue--;

            else if (cordinate.state.ToString() == "S")
                cordinate.yValue--;

            else if (cordinate.state.ToString() == "E")
                cordinate.xValue++;


            if (cordinate.xValue < 0 || cordinate.xValue > cordinate.xMaxValue || cordinate.yValue < 0 || cordinate.yValue > cordinate.yMaxValue)
                return new ErrorDataResult<Cordinate>(cordinate,"HATALI");

            return new SuccessDataResult<Cordinate>(cordinate);
        }

        public IResult Start(Cordinate cordinate ,string startValue)
        {


            foreach (var item in startValue)
            {
                if (item == 'L')
                {
                    var state = this.LValue(cordinate.state);

                    if (state.Success)
                        cordinate.state = state.Data;
                    else
                        return new ErrorResult("HATALI ISLEM " + state.Message);
                }
                else if (item == 'R')
                {
                    var state = this.RValue(cordinate.state);

                    if (state.Success)
                        cordinate.state = state.Data;
                    else
                        return new ErrorResult("HATALI ISLEM " + state.Message);
                }
                else if (item == 'M')
                {
                    var xyCordinate = this.MValue(cordinate);

                    if (xyCordinate.Success)
                        cordinate = xyCordinate.Data;
                    else
                        return new ErrorResult("HATALI ISLEM ");
                }

            }

            Console.WriteLine(cordinate.xValue + " " + cordinate.yValue + " " + cordinate.state.ToString());

            return new SuccessResult();
        }
    }
}
