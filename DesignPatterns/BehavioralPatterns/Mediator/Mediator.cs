using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Mediator
{
    //Mediator
    class Chatroom 

    {
        //1 coleagues
        private Dictionary<string, Participant> _participants =
          new Dictionary<string, Participant>();
        //2 manage coleagues
        public void Register(Participant participant)
        {
            if (!_participants.ContainsValue(participant))
            {
                _participants[participant.Name] = participant;
            }

            participant.Chatroom = this;
        }
        //3 coleagues operations
        public void Send(
          string from, string to, string message)
        {
            Participant participant = _participants[to];

            if (participant != null)
            {
                participant.Receive(from, message);
            }
        }
    }
    //Colleague
    class Participant

    {
        private string _name;
        public Participant(string name)
        {
            this._name = name;
        }
        public string Name
        {
            get { return _name; }
        }
        private Chatroom _chatroom;

        //1 Mediator Instance
        public Chatroom Chatroom
        {
            set { _chatroom = value; }
            get { return _chatroom; }
        }
        //2 Coleague Operation
        public void Send(string to, string message)
        {
            _chatroom.Send(_name, to, message);
        }
        public virtual void Receive(
          string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'",
              from, Name, message);
        }
    }
    // ConcreteColleagues
    class Beatle : Participant

    {
        // Constructor

        public Beatle(string name)
          : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To a Beatle: ");
            base.Receive(from, message);
        }
    }
    class NonBeatle : Participant

    {
        // Constructor

        public NonBeatle(string name)
          : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To a non-Beatle: ");
            base.Receive(from, message);
        }
    }
}
