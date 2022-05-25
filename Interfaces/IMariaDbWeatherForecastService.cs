using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Models;

namespace project.Interfaces
{
  public interface IMariaDbWeatherForecastService
  {
    Task<int> Delete(int id);
    Task<IEnumerable<WeatherForecastDataModel>> FindAll();
    Task<WeatherForecastDataModel> FindOne(int id);
    Task<int> Insert(WeatherForecastDataModel forecast);
    Task<int> Update(WeatherForecastDataModel forecast);
  }
}