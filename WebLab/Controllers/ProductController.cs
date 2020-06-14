using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebLab.DAL.Entities;
using WebLab.Models;

namespace WebLab.Controllers
{
    public class ProductController : Controller {
        public List<Military> _militaries;
        List<MilitaryGroup> _militaryGroups;
        int _pageSize;

        public ProductController() {
            _pageSize = 3;
            SetupData();
        }

        public IActionResult Index(int? group, int pageNo = 1) {
            var militariesFiltered = _militaries.Where(m => !group.HasValue || m.MilitaryGroupId == group.Value);
            // Поместить список групп во ViewData 
            ViewData["Groups"] = _militaryGroups;

            // Получить id текущей группы и поместить в TempData 
            var currentGroup = group.HasValue ? group.Value : 0;

            ViewData["CurrentGroup"] = currentGroup;
            return View(ListViewModel<Military>.GetModel(militariesFiltered, pageNo,_pageSize));
        }

        /// <summary> 
        /// Инициализация списков 
        /// </summary> 
        private void SetupData() {
            _militaryGroups = new List<MilitaryGroup>
            {
                new MilitaryGroup {MilitaryGroupId=1, GroupName="Артиллерия"},
                new MilitaryGroup {MilitaryGroupId=2, GroupName="Самолёты"},
                new MilitaryGroup {MilitaryGroupId=3, GroupName="Танки"}
            };

            _militaries = new List<Military>
            {
                new Military { MilitaryId = 1, MilitaryName="Долговязый Том", Description="Американская пушка", Force=3
                    , MilitaryGroupId=1, Image="art_longTom.jpg" },
                new Military { MilitaryId = 2, MilitaryName="Нора", Description="Бронированная машинка", Force=120
                    , MilitaryGroupId=1, Image="art_nora.jpg" },
                new Military { MilitaryId = 3, MilitaryName="Пион", Description="Крутая гаубица", Force=250
                    , MilitaryGroupId=1, Image="art_pion.jpg" },
                new Military { MilitaryId = 4, MilitaryName="Смерч", Description="Катюша new", Force=500
                    , MilitaryGroupId=1, Image="art_smerch.jpg" },

                new Military { MilitaryId = 5, MilitaryName="Су-27", Description="Выше всяких похвал", Force=10500
                    , MilitaryGroupId=2, Image="air_su27.jpg" },
                new Military { MilitaryId = 6, MilitaryName="Hawker Siddeley Harrier", Description="Английский, вертикальный, 1-й в своём роде", Force=770
                    , MilitaryGroupId=2, Image="air_harrier.jpg" },
                new Military { MilitaryId = 7, MilitaryName="F-15", Description="Стабильность", Force=330
                    , MilitaryGroupId=2, Image="air_f15.jpg" },
                new Military { MilitaryId = 8, MilitaryName="F-22", Description="Мишура", Force=13
                    , MilitaryGroupId=2, Image="air_f22.jpg" },

                new Military { MilitaryId = 9, MilitaryName="Армата", Description="4-е поколение. Лучше не попадаться на глаза", Force=1000
                    , MilitaryGroupId=3, Image="tank_armata.jpg" },
                new Military { MilitaryId = 10, MilitaryName="Меркава", Description="Против арам-зам-зам", Force=500
                    , MilitaryGroupId=3, Image="tank_merkava.jpg" },
                new Military { MilitaryId = 11, MilitaryName="Леопард-2", Description="Немецкое качество", Force=800
                    , MilitaryGroupId=3, Image="tank_leopard2.jpg" },
                new Military { MilitaryId = 12, MilitaryName="Абрамс", Description="Старьё", Force=33
                    , MilitaryGroupId=3, Image="tank_abrams.jpg" }
            };
        }
    }
}