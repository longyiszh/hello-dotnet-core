using System;

namespace EmberMug.Lib
{

    public class LinkedNode<T>
    {
        public string ID { get; }
        public T Data { get; }
        public LinkedNode<T> Next { get; set; }
        public LinkedNode()
        {
            this.ID = Guid.NewGuid().ToString();
        }

        public LinkedNode(T data)
        {
            this.ID = Guid.NewGuid().ToString();
            this.Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }

}
