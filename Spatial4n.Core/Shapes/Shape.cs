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

using Spatial4n.Core.Context;

namespace Spatial4n.Core.Shapes
{
	/// <summary>
	/// Shape instances are usually retrieved via one of the create* methods on a {@link SpatialContext}.
	/// Shapes are generally immutable and thread-safe.
	/// The sub-classes of Shape generally implement the same contract for {@link Object#equals(Object)}
	/// and {@link Object#hashCode()} amongst the same sub-interface type.  This means, for example, that
	/// multiple Point implementations of different classes are equal if they share the same x & y.
	/// </summary>
	public interface Shape
	{
		/// <summary>
		/// Describe the relationship between the two objects.  For example
		/// <ul>
		///   <li>this is WITHIN other</li>
		///   <li>this CONTAINS other</li>
		///   <li>this is DISJOINT other</li>
		///   <li>this INTERSECTS other</li>
		/// </ul>
		/// Note that a Shape implementation may choose to return INTERSECTS when the
		/// true answer is WITHIN or CONTAINS for performance reasons. If a shape does
		/// this then it <i>must</i> document when it does.  Ideally the shape will not
		/// do this approximation in all circumstances, just sometimes.
		/// <p />
		/// If the shapes are equal then the result is CONTAINS (preferred) or WITHIN.
		/// </summary>
		/// <param name="other"></param>
		/// <param name="ctx"></param>
		/// <returns></returns>
		SpatialRelation Relate(Shape other, SpatialContext ctx);

		/// <summary>
		/// Get the bounding box for this Shape. This means the shape is within the
		/// bounding box and that it touches each side of the rectangle.
		/// <p/>
		/// Postcondition: <code>this.getBoundingBox().relate(this) == CONTAINS</code>
		/// </summary>
		/// <returns></returns>
		Rectangle GetBoundingBox();

		/// <summary>
		/// Does the shape have area?  This will be false for points and lines. It will
		/// also be false for shapes that normally have area but are constructed in a
		/// degenerate case as to not have area (e.g. a circle with 0 radius or
		/// rectangle with no height or no width).
		/// </summary>
		/// <returns></returns>
		bool HasArea();

		/// <summary>
		/// Calculates the area of the shape in the units of {@link
		/// com.spatial4j.core.distance.DistanceUnits}. If ctx is null then simple
		/// Euclidean calculations will be used.  This figure can be an estimate.
		/// </summary>
		/// <param name="ctx"></param>
		/// <returns></returns>
		double GetArea(SpatialContext ctx);

		/// <summary>
		/// Returns the center point of this shape. This is usually the same as
		/// <code>getBoundingBox().getCenter()</code> but it doesn't have to be.
		/// <p />
		/// Postcondition: <code>this.relate(this.getCenter()) == CONTAINS</code>
		/// </summary>
		/// <returns></returns>
		Point GetCenter();
	}
}
