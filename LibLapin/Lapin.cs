using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibLapin
{
    public class Lapin
    {
        private string surnom;
        private int age;
        private int position;
        private int dossard;
        private static Random aleatoire;
        private State state;
        public static int lastId;
        private int id;

        static Lapin()
        {
            Lapin.lastId = 0;
        }


        public Lapin(string surnom, int age)
        {
            this.surnom = surnom;
            this.age = age;
            this.position = 0;
            Lapin.aleatoire = new Random();
            Lapin.lastId += 1;
            this.id = Lapin.lastId;
        }

        public Lapin(int id, string surnom, int age, int dossard, int position, State state)
        {
            this.id = id;
            this.surnom = surnom;
            this.age = age;
            this.dossard = dossard;
            this.position = position;
            this.state = state;
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public int Position
        {
            get { return this.position; }
        }

        public string Surnom
        {
            get { return this.surnom; }
            set { this.surnom = value; }
        }

        public int Dossard
        {
            get { return this.dossard; }
            set { this.dossard = value; }
        }

        public State State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public int Id
        {
            get { return this.id; }
        }

        public void Avancer()
        {
            this.position += Lapin.aleatoire.Next(0, 6);
        }

        public void Remove()
        {
            this.state = State.deleted;
        }

        public override string ToString()
        {
            return string.Format("Un lapin nommé {0}, agé de {1} an(s), dont la position est {2}", this.surnom, this.age, this.position);
        }

    }
}
