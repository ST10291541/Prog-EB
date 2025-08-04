using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DoublyLinkedLists
{
    public partial class MainWindow : Window
    {
        private DoublyLinkedList<string> playlist = new DoublyLinkedList<string>();

        public MainWindow()
        {
            InitializeComponent();
            RefreshPlaylist();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TitleBox.Text))
            {
                playlist.AddLast(TitleBox.Text);
                TitleBox.Clear();
                RefreshPlaylist();
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            playlist.MoveNext();
            RefreshPlaylist();
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            playlist.MovePrevious();
            RefreshPlaylist();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            playlist.RemoveCurrent();
            RefreshPlaylist();
        }

        private void RefreshPlaylist()
        {
            PlaylistBox.Items.Clear();
            foreach (var track in playlist)
                PlaylistBox.Items.Add(track);

            CurrentTrackBlock.Text = playlist.Current ?? "No Track";
        }
    }

    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private class Node
        {
            public T Data;
            public Node Next;
            public Node Prev;

            public Node(T data)
            {
                Data = data;
            }
        }

        private Node head, tail, current;

        public string Current => current?.Data?.ToString();

        public void AddLast(T item)
        {
            var node = new Node(item);
            if (head == null)
                head = tail = current = node;
            else
            {
                tail.Next = node;
                node.Prev = tail;
                tail = node;
            }
        }

        public void MoveNext()
        {
            if (current?.Next != null)
                current = current.Next;
        }

        public void MovePrevious()
        {
            if (current?.Prev != null)
                current = current.Prev;
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

            current = current.Next ?? current.Prev;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = head;
            while (node != null)
            {
                yield return node.Data;
                node = node.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
