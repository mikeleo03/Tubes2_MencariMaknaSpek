﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt.Container
{
    class Route
    {
        // private section
        private List<Coordinate> routes;
        private List<Coordinate> visitedTreasure;
        private int numsTreasure;
        private int length;
        private Coordinate currentCoordinate;

        // public section
        // constructor
        public Route()
        {
            this.numsTreasure = 0;
            this.length = 0;
            this.routes = new List<Coordinate>();
            this.visitedTreasure = new List<Coordinate>();
            this.currentCoordinate = new Coordinate();
        }

        // getter
        public int getNumsTreasure()
        {
            return this.numsTreasure;
        }

        public Coordinate getCurrentCoordinate()
        {
            return this.currentCoordinate;
        }

        public void addNumsTreasure(Coordinate treasurePoint)
        {
            this.numsTreasure++;
            this.visitedTreasure.Add(treasurePoint);
        }

        public bool isTreasureVisited(Coordinate treasurePoint)
        {
            for (int i = 0; i < this.visitedTreasure.Count; i++)
            {
                if (this.visitedTreasure[i].getX() == treasurePoint.getX() && this.visitedTreasure[i].getY() == treasurePoint.getY())
                {
                    return true;
                }
            }
            return false;
        }

        public int getRouteLength()
        {
            return this.length;
        }

        public int getRoutesTopX()
        {
            return this.routes[this.length - 1].getX();
        }

        public int getRoutesTopY()
        {
            return this.routes[this.length - 1].getY();
        }

        public Coordinate getRoutesTop()
        {
            return this.routes[this.length - 1];
        }

        public List<Coordinate> getRoutes()
        {
            return this.routes;
        }

        public void addElement(Coordinate coord)
        {
            this.routes.Add(coord);
            this.currentCoordinate = coord;
            this.length++;
        }

        public void copyRoute(Route oldRoutes)
        {
            this.length = oldRoutes.getRouteLength();
            this.numsTreasure = oldRoutes.getNumsTreasure();
            this.routes = new List<Coordinate>();
            for (int i = 0; i < getRouteLength(); i++)
            {
                this.routes.Add(oldRoutes.routes[i]);
            }
            this.visitedTreasure = new List<Coordinate>();
            for (int i = 0; i < oldRoutes.visitedTreasure.Count; i++)
            {
                this.visitedTreasure.Add(oldRoutes.visitedTreasure[i]);
            }
            this.currentCoordinate = oldRoutes.getCurrentCoordinate();
        }

        public List<String> getSequenceOfDirection()
        {
            List<String> sequence = new List<String>();
            for (int i = 0; i < getRouteLength() - 1; i++)
            {
                if (this.routes[i + 1].getX() > this.routes[i].getX())
                {
                    sequence.Add("D");
                }
                else if (this.routes[i + 1].getX() < this.routes[i].getX())
                {
                    sequence.Add("U");
                }
                else if (this.routes[i + 1].getY() > this.routes[i].getY())
                {
                    sequence.Add("R");
                }
                else
                {
                    sequence.Add("L");
                }
            }
            return sequence;
        }

        public void printPath()
        {
            for (int i = 0; i < getRouteLength(); i++)
            {
                Console.WriteLine($"pathhh: \t({routes[i].getX()}, {routes[i].getY()}) -");
            }
        }
    }
}