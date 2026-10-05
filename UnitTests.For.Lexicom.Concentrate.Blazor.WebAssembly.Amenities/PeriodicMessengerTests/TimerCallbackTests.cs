using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Messages;
using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
using Lexicom.DependencyInjection.Primitives;
using Lexicom.Testing.DependencyInjection;
using NSubstitute;
using UnitTests.For.Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Constructs;

namespace UnitTests.For.Lexicom.Concentrate.Blazor.WebAssembly.Amenities.PeriodicMessengerTests;

public class TimerCallbackTests
{
    [Fact]
    public async Task Periodic_Messenger_Sends_Message()
    {
        //arrange
        var utcNow = new DateTimeOffset(2026, 10, 21, 8, 8, 8, TimeSpan.Zero);

        var uta = new UnitTestAssistant();
        uta
            .Mock<ITimeProvider>()
            .So(tp =>
            {
                tp
                    .GetUtcNow()
                    .Returns(utcNow);
            });
        var messenger = uta
            .Mock<IMessenger>()
            .With<TestMessenger>()
            .Pull();

        var periodicMessenger = uta.Make<PeriodicMessenger>();

        Assert.Empty(messenger.Messages);

        periodicMessenger.Start(TimeSpan.FromSeconds(1));

        bool messaged = false;
        while (!messaged)
        {
            messaged = messenger.Messages.Count is > 0;
        }

        periodicMessenger.Dispose();

        var message = (PeriodicTickMessage)Assert.Single(messenger.Messages);
        Assert.Equal(message.UtcNow, utcNow);
    }
}
