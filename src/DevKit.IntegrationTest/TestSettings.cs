﻿//----------------------------------------------------------------------- 
// ETP DevKit, 1.1
//
// Copyright 2016 Energistics
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-----------------------------------------------------------------------

using Energistics.IntegrationTest;

namespace Energistics
{
    /// <summary>
    /// Defines static fields for the ETP test settings.
    /// </summary>
    public static class TestSettings
    {
        /// <summary>
        /// The default authentication token URL
        /// </summary>
        public static string AuthTokenUrl = Settings.Default.AuthTokenUrl;

        /// <summary>
        /// The default server URL
        /// </summary>
        public static string ServerUrl = Settings.Default.ServerUrl;

        /// <summary>
        /// The default username
        /// </summary>
        public static string Username = Settings.Default.Username;

        /// <summary>
        /// The default password
        /// </summary>
        public static string Password = Settings.Default.Password;

        /// <summary>
        /// The default server capabilities URL
        /// </summary>
        public static string ServerCapabilitiesUrl = Settings.Default.ServerCapabilitiesUrl;

        /// <summary>
        /// The default ETP version
        /// </summary>
        public static string EtpVersion = Properties.Settings.Default.EtpVersion;

        /// <summary>
        /// The default timeout in milliseconds
        /// </summary>
        public const int DefaultTimeoutInMilliseconds = 5000;
    }
}