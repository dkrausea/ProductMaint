﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JQueryDataTables.Models;
using JQueryDataTables.Models.Repository;

namespace JQueryDataTables.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Action that handles initiall request and returns empty view
        /// </summary>
        /// <returns>Home/Index view</returns>
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Returns data by the criterion
        /// </summary>
        /// <param name="param">Request sent by DataTables plugin</param>
        /// <returns>JSON text used to display data
        /// <list type="">
        /// <item>sEcho - same value as in the input parameter</item>
        /// <item>iTotalRecords - Total number of unfiltered data. This value is used in the message: 
        /// "Showing *start* to *end* of *iTotalDisplayRecords* entries (filtered from *iTotalDisplayRecords* total entries)
        /// </item>
        /// <item>iTotalDisplayRecords - Total number of filtered data. This value is used in the message: 
        /// "Showing *start* to *end* of *iTotalDisplayRecords* entries (filtered from *iTotalDisplayRecords* total entries)
        /// </item>
        /// <item>aoData - Twodimensional array of values that will be displayed in table. 
        /// Number of columns must match the number of columns in table and number of rows is equal to the number of records that should be displayed in the table</item>
        /// </list>
        /// </returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            var allCompanies = DataRepository.GetCompanies();
            IEnumerable<Company> filteredCompanies;
            //Check whether the companies should be filtered by keyword
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                //Used if particulare columns are filtered 
                var nameFilter = Convert.ToString(Request["sSearch_1"]);
                var addressFilter = Convert.ToString(Request["sSearch_2"]);
                var townFilter = Convert.ToString(Request["sSearch_3"]);
                var stateFilter = Convert.ToString(Request["sSearch_4"]);
                var postalCodeFilter = Convert.ToString(Request["sSearch_5"]);
                var BuildingFilter = Convert.ToString(Request["sSearch_6"]);

                //Optionally check whether the columns are searchable at all 
                var isNameSearchable = Convert.ToBoolean(Request["bSearchable_1"]);
                var isAddressSearchable = Convert.ToBoolean(Request["bSearchable_2"]);
                var isCitySearchable = Convert.ToBoolean(Request["bSearchable_3"]);
                var isStateSearchable = Convert.ToBoolean(Request["bSearchable_4"]);
                var isPostalCodeSearchable = Convert.ToBoolean(Request["bSearchable_5"]);
                var isBuildingSearchable = Convert.ToBoolean(Request["bSearchable_6"]);

                filteredCompanies = DataRepository.GetCompanies()
                   .Where(c => isNameSearchable && c.Name.ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isAddressSearchable && c.Address.ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isCitySearchable && c.City.ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isStateSearchable && c.State.ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isPostalCodeSearchable && c.PostalCode.ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isBuildingSearchable && c.Building.ToLower().Contains(param.sSearch.ToLower()) 
                               );
            }
            else
            {
                filteredCompanies = allCompanies;
            }

            var isNameSortable = Convert.ToBoolean(Request["bSortable_1"]);
            var isAddressSortable = Convert.ToBoolean(Request["bSortable_2"]);
            var isCitySortable = Convert.ToBoolean(Request["bSortable_3"]);
            var isStateSortable = Convert.ToBoolean(Request["bSortable_4"]);
            var isPostalCodeSortable = Convert.ToBoolean(Request["bSortable_5"]);
            var isBuildingSortable = Convert.ToBoolean(Request["bSortable_6"]);
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Company, string> orderingFunction = (c => sortColumnIndex == 1 && isNameSortable ? c.Name :
                                                           sortColumnIndex == 2 && isAddressSortable ? c.Address :
                                                           sortColumnIndex == 3 && isCitySortable ? c.City :
                                                           sortColumnIndex == 4 && isStateSortable ? c.State : 
                                                           sortColumnIndex == 5 && isPostalCodeSortable ? c.PostalCode :
                                                           sortColumnIndex == 6 && isBuildingSortable ? c.Building :
                                                           "");

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
                filteredCompanies = filteredCompanies.OrderBy(orderingFunction);
            else
                filteredCompanies = filteredCompanies.OrderByDescending(orderingFunction);

            var displayedCompanies = filteredCompanies.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedCompanies select new[] { Convert.ToString(c.ID), c.Name, c.Address, c.City, c.State, c.PostalCode, c.Building };
            return Json(new
                            {
                                sEcho = param.sEcho,
                                iTotalRecords = allCompanies.Count(),
                                iTotalDisplayRecords = filteredCompanies.Count(),
                                aaData = result
                            },
                        JsonRequestBehavior.AllowGet);
        }

    }
}
