using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedLists
{
    using System;
    using System.Collections.Generic;

    public class Playlist
    {
        private Node<Track> head;
        private Node<Track> tail;
        private Node<Track> current;

        public Track CurrentTrack => current?.Data;

        public void AddTrack(string title, string artist)
        {
            var newNode = new Node<Track>(new Track(title, artist));
            if (head == null)
            {
                head = tail = current = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
        }

        public void RemoveCurrent()
        {
            if (current == null) return;

            if (current.Prev != null)
                current.Prev.Next = current.Next;
            else
                head = current.Next;

            if (current.Next != null)
                current.Next.Prev = current.Prev;
            else
                tail = current.Prev;

            current = current.Next ?? current?.Prev;
        }

        public void Next()
        {
            if (current?.Next != null)
                current = current.Next;
        }

        public void Previous()
        {
            if (current?.Prev != null)
                current = current.Prev;
        }

        public List<Track> ToList()
        {
            var list = new List<Track>();
            var temp = head;
            while (temp != null)
            {
                list.Add(temp.Data);
                temp = temp.Next;
            }
            return list;
        }

        public void Shuffle()
        {
            var allTracks = ToList();
            var rand = new Random();
            for (int i = 0; i < allTracks.Count; i++)
            {
                int j = rand.Next(i, allTracks.Count);
                (allTracks[i], allTracks[j]) = (allTracks[j], allTracks[i]);
            }

            head = tail = current = null;
            foreach (var track in allTracks)
            {
                AddTrack(track.Title, track.Artist);
            }
        }
    }

}
