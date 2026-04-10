using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructureLibrary.Graph;

public class Graph<TVertexProperty, TEdgeProperty>
where TVertexProperty : BasicVertexProperty, new()
where TEdgeProperty : BasicEdgeProperty<Vertex<TVertexProperty>>, new()
{
    private readonly LinkedList<Vertex<TVertexProperty>> _vertices;
    private readonly LinkedList<Edge<Vertex<TVertexProperty>, TEdgeProperty>> _edges;

    public Graph()
    {
        _vertices = new LinkedList<Vertex<TVertexProperty>>();
        _edges = new LinkedList<Edge<Vertex<TVertexProperty>, TEdgeProperty>>();
    }

    public Vertex<TVertexProperty> AddVertex(string name)
    {
        Vertex<TVertexProperty>? v = HasVertex(name);

        if (v == null)
        {
            Vertex<TVertexProperty> newV = new Vertex<TVertexProperty>(name);
            _vertices.AddLast(newV);
            return newV;
        }

        return v;
    }

    public void RemoveVertex(string name)
    {
        Vertex<TVertexProperty>? v = HasVertex(name);

        if (v != null)
        {
            // Da LinkedList kein RemoveAll hat, sammeln wir die Kanten manuell
            var edgesToRemove = new List<Edge<Vertex<TVertexProperty>, TEdgeProperty>>();

            foreach (var e in _edges)
            {
                if (e.Property.Source == v || e.Property.Target == v)
                {
                    edgesToRemove.Add(e);
                }
            }

            // Kanten löschen
            foreach (var e in edgesToRemove)
            {
                _edges.Remove(e);
            }

            // Knoten löschen
            _vertices.Remove(v);
        }
    }

    public Vertex<TVertexProperty>? HasVertex(string name)
    {
        foreach (Vertex<TVertexProperty> v in _vertices)
        {
            if (v.Property.Name == name)
                return v;
        }
        return null;
    }

    public Edge<Vertex<TVertexProperty>, TEdgeProperty>? AddEdge(Vertex<TVertexProperty>? source, Vertex<TVertexProperty>? target)
    {
        if (source == null || target == null)
        {
            Console.WriteLine("Source oder Target Vertex konnte nicht gefunden werden.");
            return null;
        }

        Edge<Vertex<TVertexProperty>, TEdgeProperty>? e = HasEdge(source, target);

        if (e == null)
        {
            Edge<Vertex<TVertexProperty>, TEdgeProperty> newE = new Edge<Vertex<TVertexProperty>, TEdgeProperty>(source, target);
            _edges.AddLast(newE);
            return newE;
        }

        return e;
    }

    public void RemoveEdge(Vertex<TVertexProperty>? source, Vertex<TVertexProperty>? target)
    {
        Edge<Vertex<TVertexProperty>, TEdgeProperty>? e = HasEdge(source, target);

        if (e != null)
        {
            _edges.Remove(e);
        }
        else
        {
            Console.WriteLine("Edge konnte nicht gefunden werden.");
        }
    }

    public Edge<Vertex<TVertexProperty>, TEdgeProperty>? HasEdge(Vertex<TVertexProperty>? source, Vertex<TVertexProperty>? target)
    {
        if (source == null || target == null) return null;

        foreach (Edge<Vertex<TVertexProperty>, TEdgeProperty> e in _edges)
        {
            if ((e.Property.Source == source) && (e.Property.Target == target))
                return e;
        }
        return null;
    }

    public void PrintGraph()
    {
        Console.WriteLine("Total Vertex Number: " + _vertices.Count);
        Console.WriteLine("Total Edge Number: " + _edges.Count);
        Console.WriteLine("======================");

        foreach (Vertex<TVertexProperty> v in _vertices)
        {
            Console.WriteLine(v);
        }
        Console.WriteLine("======================");

        foreach (Edge<Vertex<TVertexProperty>, TEdgeProperty> e in _edges)
        {
            Console.WriteLine(e);
        }
        Console.WriteLine("======================");
    }
}