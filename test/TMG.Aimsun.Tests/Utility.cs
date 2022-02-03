﻿/*
    Copyright 2022 Travel Modelling Group, Department of Civil Engineering, University of Toronto

    This file is part of TMGToolbox for Aimsun.

    TMGToolbox for Aimsun is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    TMGToolbox for Aimsun is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with TMGToolbox for Aimsun.  If not, see <http://www.gnu.org/licenses/>.
*/

using Newtonsoft.Json;
using System.IO;

namespace TMG.Aimsun.Tests
{
    public static class Utility
    {
        /// <summary>
        /// Method to run a given Aimsun tool
        /// </summary>
        /// <param name="nwpFile">string path of network pacakge nwp file</param>
        /// <param name="toolPath">string path to Aimsun tool name </param>
        public static void RunImportNetworkTool(string nwpFile, string toolPath)
        {
            string modulePath = Path.Combine(Helper.TestConfiguration.ModulePath, toolPath);
            string jsonParameters = JsonConvert.SerializeObject(new
            {
                NetworkPackageFile = nwpFile
            });
            Helper.Modeller.Run(null, modulePath, jsonParameters);
        }

        /// <summary>
        /// A method to run the ImportPedestrian Tool
        /// </summary>
        public static void RunImportPedestriansTool()
        {
            string modulePath = Path.Combine(Helper.TestConfiguration.ModulePath, "inputOutput\\importPedestrians.py");
            string jsonParameters = JsonConvert.SerializeObject(new
            {
            });
            Helper.Modeller.Run(null, modulePath, jsonParameters);
        }

        /// <summary>
        /// Run the ImportTransitScheduleTool to create a transit schedule
        /// </summary>
        /// <param name="nwpFile">Path to network nwp package file as a string</param>
        /// <param name="serviceTablePath">Path to csv serviceTable csv file as a string</param>
        public static void RunImportTransitScheduleTool(string nwpFile, string serviceTablePath)
        {
            string modulePath = Helper.BuildModulePath("inputOutput\\importTransitSchedule.py");
            string jsonParameters = JsonConvert.SerializeObject(new
            {
                NetworkPackageFile = nwpFile,
                ServiceTableCSV = serviceTablePath
            });
            Helper.Modeller.Run(null, modulePath, jsonParameters);
        }

        /// <summary>
        /// Method to run the importmatrix tool which imports various matrixes 
        /// </summary>
        /// <param name="matrixCSV">path to location of matrix csv file as a string</param>
        /// <param name="odCSV">path to location of OD csv file as a string</param>
        /// <param name="thirdNormalized">boolean value </param>
        /// <param name="includeHeader">boolean value if headers are to be included</param>
        /// <param name="matrixID">string name of the matrix to be used as an ID</param>
        /// <param name="centroidconfig">string name of the centroid configuration to be used as an ID</param>
        /// <param name="vehicleType">string type of vehicle to use eg car, bus, etc....</param>
        /// <param name="initialTime">string of initial time in minutes</param>
        /// <param name="durationTime">string of duration in minutes</param>
        public static void RunImportMatrixFromCSVThirdNormalizedTool(string matrixCSV, string odCSV, bool thirdNormalized, bool includeHeader,
                                                                       string matrixID, string centroidconfig, string vehicleType,
                                                                       string initialTime, string durationTime)
        {
            string modulePath = Helper.BuildModulePath("inputOutput\\importMatrixFromCSVThirdNormalized.py");
            string jsonParameters = JsonConvert.SerializeObject(new
            {
                MatrixCSV = matrixCSV,
                ODCSV = odCSV,
                ThirdNormalized = thirdNormalized,
                IncludesHeader = includeHeader,
                MatrixID = matrixID,
                CentroidConfiguration = centroidconfig,
                VehicleType = vehicleType,
                InitialTime = initialTime,
                DurationTime = durationTime
            });
            Helper.Modeller.Run(null, modulePath, jsonParameters);
        }

        /// <summary>
        /// Method to run the Road Assignment tool and generate the roads in the model
        /// </summary>
        /// <param name="toolPath">string path of which assignment tool to run</param>
        /// <param name="autodemand">string name of autodemand</param>
        /// <param name="starttime">double start time in minutes </param>
        /// <param name="durationtime">double duration time in minutes</param>
        /// <param name="transitdemand">string name of transit demand</param>
        public static void RunAssignmentTool(string toolPath, string autodemand, double starttime, 
                                                    double durationtime, string transitdemand)
        {
            string modulePath = Path.Combine(Helper.TestConfiguration.ModulePath, toolPath);
            //string modulePath = Helper.BuildModulePath("assignment\\roadAssignment.py");
            string jsonParameters = JsonConvert.SerializeObject(new
            {
                autoDemand = autodemand,
                Start = starttime,
                Duration = durationtime,
                transitDemand = transitdemand
            });
            Helper.Modeller.Run(null, modulePath, jsonParameters);
        }
    }
}