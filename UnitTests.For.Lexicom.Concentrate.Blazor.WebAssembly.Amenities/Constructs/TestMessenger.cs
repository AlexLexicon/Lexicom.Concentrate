using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using Lexicom.Mvvm;

namespace UnitTests.For.Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Constructs;

public class TestMessenger : IAsyncMessenger
{
    public TestMessenger()
    {
        InternalMessages = new List<object>();
    }

    private List<object> InternalMessages { get; }
    public IReadOnlyList<object> Messages => InternalMessages;

    public void AsyncRegister<TMessage>(IAsyncRecipient<TMessage> recipient) where TMessage : class
    {
    }

    public Task SendAsync<TMessage>(TMessage message, AsyncMessageAwaitStrategy asyncMessageAwaitStrategy, CancellationToken cancellationToken = default) where TMessage : class
    {
        InternalMessages.Add(message);

        return Task.CompletedTask;
    }

    public Task ScheduleAsync<TMessage>(TMessage message, ScheduleMessagePriority scheduleMessagePriority, AsyncMessageAwaitStrategy asyncMessageAwaitStrategy, CancellationToken cancellationToken = default) where TMessage : class
    {
        InternalMessages.Add(message);

        return Task.CompletedTask;
    }

    public bool IsRegistered<TMessage, TToken>(object recipient, TToken token)
        where TMessage : class
        where TToken : IEquatable<TToken>
    {
        return false;
    }

    public void Register<TRecipient, TMessage, TToken>(TRecipient recipient, TToken token, MessageHandler<TRecipient, TMessage> handler)
        where TRecipient : class
        where TMessage : class
        where TToken : IEquatable<TToken>
    {
    }

    public void UnregisterAll(object recipient)
    {
    }

    public void UnregisterAll<TToken>(object recipient, TToken token) where TToken : IEquatable<TToken>
    {
    }

    public void Unregister<TMessage, TToken>(object recipient, TToken token)
        where TMessage : class
        where TToken : IEquatable<TToken>
    {
    }

    public TMessage Send<TMessage, TToken>(TMessage message, TToken token)
        where TMessage : class
        where TToken : IEquatable<TToken>
    {
        InternalMessages.Add(message);

        return message;
    }

    public void Cleanup()
    {
    }

    public void Reset()
    {
    }
}
