﻿/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace Spatial4n.Core.Shapes
{
	/// <summary>
	/// A Point with X & Y coordinates.
	/// </summary>
	public interface Point : Shape
	{
		/// <summary>
		/// The X coordinate, or Longitude in geospatial contexts.
		/// </summary>
		/// <returns></returns>
		double GetX();

		/// <summary>
		/// The Y coordinate, or Latitude in geospatial contexts.
		/// </summary>
		/// <returns></returns>
		double GetY();
	}
}
