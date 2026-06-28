using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibLapin;

namespace LibLapin
{
    public class Course
    {
        private int distance;
        private List<Lapin> participants;
        private int id;
        private State state;

        public Course(int distance)
        {
            this.distance = distance;
            this.participants = new List<Lapin>();
        }

        public Course(int id, int distance, State state)
        {
            this.id = id;
            this.distance = distance;
            this.state = state;
            this.participants = new List<Lapin>();
        }
        public int Count
        {
            get { return this.participants.Count(); }
        }
        public List<Lapin> Participer
        {
            get { return this.participants; }
        }
        public int Id
        {
            get { return this.id; }
        }

        public int Distance
        {
            get { return this.distance; }
            set { this.distance = value; }
        }

        public void Add(Lapin Lapin)
        {
            this.participants.Add(Lapin);
        }

        public void Depart()
        {
            for (int i = 0; i < this.distance; i++)
            {
                for (int y = 0; y < this.Count; y++)
                {
                    this.participants[y].Avancer();
                }
            }
        }
        public Lapin Gagnant()
        {
            int maxP = this.participants[0].Position;
            Lapin gagnant = this.participants[0];
            for (int i = 1; i < this.Count; i++)
            {
                if (this.participants[i].Position >= maxP)
                {
                    maxP = this.participants[i].Position;
                    gagnant = this.participants[i];
                }
            }
            return gagnant;
        }

        public State State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public void Remove()
        {
            this.state = State.deleted;
        }

        public void RemoveAt(int position)
        {
            this.participants.RemoveAt(position);
        }

        public override string ToString()
        {
            return string.Format("La course fait {0}m de long, et il y a {1} participant(s).", this.distance, this.participants.Count());
        }
    }
}
