using ProductApp.Models;
using ProductApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApp.Domain
{
    public class DiffService
    {
        public JsonResponse Compare(int id)
        {
            JsonResponse response = new JsonResponse();
            LeftRepository leftRepository = new LeftRepository();
            RightRepository rightRepository = new RightRepository();
            Base64Data leftData = leftRepository.GetById(id);
            Base64Data rightData = rightRepository.GetById(id);
            response.Left = leftData.Base64Value;
            response.Right = rightData.Base64Value;
            response.Id = id;

            //Validate if right or left data is present
            if (leftData == null && rightData == null)
            {
                response.Result = "Id " + id + " does not exists in Left and Right side";
            }
            else if (leftData == null)
            {
                response.Result = "Id " + id + " does not exists in Left side";
            }
            else if(rightData == null)
            {
                response.Result = "Id " + id + " does not exists in Right side";
            }
            //Validate if right and left data are of equal size
            else if (!leftData.Base64Value.Length.Equals(rightData.Base64Value.Length))
            {
                response.Result = "Not of Equal Size";
            }
            else if (leftData.Base64Value.Equals(rightData.Base64Value))
            {
                response.Result = "Equals";
            }
            else
            {
                //Check the actual differences between the strings
                string diffMessage = string.Empty;
                bool diffFound = false;
                for (int i = 0; i < leftData.Base64Value.Length; i++)
                {
                    if (!leftData.Base64Value[i].Equals(rightData.Base64Value[i]) && diffFound == false)
                    {
                        diffMessage = "Difference in position " + i;
                        diffFound = true;
                        if(i == leftData.Base64Value.Length - 1)
                        {
                            diffFound = false;
                            response.Differences.Add(diffMessage);
                        }
                    }
                    else if (leftData.Base64Value[i].Equals(rightData.Base64Value[i]) && diffFound)
                    {
                        diffMessage = diffMessage + " to " + (i-1);
                        diffFound = false;
                        response.Differences.Add(diffMessage);
                    }
                }
                response.Result = "Number of differences found: " + response.Differences.Count + ".";
            }

            return response;

        }
    }
}