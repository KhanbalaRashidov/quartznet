using System.Runtime.Serialization.Formatters.Binary;

using Quartz.Spi;

namespace Quartz.Simpl;

/// <summary>
/// Default object serialization strategy that uses <see cref="BinaryFormatter" />
/// under the hood.
/// </summary>
/// <author>Marko Lahma</author>
internal sealed class BinaryObjectSerializer : IObjectSerializer
{
    public void Initialize()
    {
    }

    /// <summary>
    /// Serializes given object as bytes
    /// that can be stored to permanent stores.
    /// </summary>
    /// <param name="obj">Object to serialize.</param>
    public byte[] Serialize<T>(T obj) where T : class
    {
#pragma warning disable SYSLIB0011
        using MemoryStream ms = new();
        BinaryFormatter bf = new();
        bf.Serialize(ms, obj);

        return ms.ToArray();
#pragma warning restore SYSLIB0011
    }

    /// <summary>
    /// Deserializes object from byte array presentation.
    /// </summary>
    /// <param name="data">Data to deserialize object from.</param>
    public T? DeSerialize<T>(byte[] data) where T : class
    {
#pragma warning disable SYSLIB0011
        using MemoryStream ms = new(data);
        BinaryFormatter bf = new();
        return (T?) bf.Deserialize(ms);

#pragma warning restore SYSLIB0011
    }
}