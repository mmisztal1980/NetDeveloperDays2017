using DemoApp.Stations;
using DemoApp.Stations.Model;
using DemoApp.Stations.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoApp.Web.Controllers
{
    public class StationsController : Controller
    {
        private readonly ISensorApiService service;
        private readonly IStationRepository repository;

        public StationsController(ISensorApiService service, IStationRepository repository)
        {
            this.service = service;
            this.repository = repository;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var svc = (await this.service.GetAllStationsAsync())
                .OrderBy(x => x.Name)
                .ToArray();

            return View(svc);
        }

        public async Task<IActionResult> Sensors(long id)
        {
            var sensors = await this.service.GetStationSensors(new DTO.Station { Id = id });

            ViewBag.Id = id;
            ViewBag.Sensors = sensors;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDevices()
        {
            var dtos = (await this.service.GetAllStationsAsync()).ToList();
            var ids = dtos.Select(x => x.Id).ToArray();
            var entities = await this.repository.GetByExternalIdAsync(ids);

            var entityIds = entities?.Select(e => e.ExternalId).ToArray() ?? new long[0];

            var newDtoIds = ids.Except(entityIds);
            var newDtos = dtos.Where(dto => newDtoIds.Contains(dto.Id)).ToArray();

            await StationAggregate.NewAsync(repository, newDtos);

            return RedirectToAction("Index", "Stations");
        }
    }
}