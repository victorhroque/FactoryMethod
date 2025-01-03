﻿using DemoResolution.Application.Command;
using DemoResolution.Domain.Interfaces;
using DemoResolution.Domain.POCO;
using Moq;

namespace DemoResolution.Tests
{
    public class CreateResolutionCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidateResolutionCode_CreateCorrectPDF()
        {
            // Arrange
            var mockDocumentFactoryProvider = new Mock<IDocumentFactoryProvider>();
            var mockDocumentFactory = new Mock<IDocumentFactory>();
            var mockDocument = new Mock<IDocument>();

            var expectedGuid = Guid.NewGuid();
            var expectedDecanalResolution = new DecanalResolution
            {
                Code = expectedGuid.ToString(),
                StudentCode = "12345678",
                Description = "Resolución de jurado",
                FilePath = $"{expectedGuid}.pdf"
            };

            mockDocumentFactoryProvider.Setup(x => x.GetFactory("ResolutionJury")).Returns(mockDocumentFactory.Object);
            mockDocumentFactory.Setup(x => x.CreateDocument()).Returns(mockDocument.Object);
            mockDocument.Setup(x => x.CreatePDF("12345678")).Returns(expectedDecanalResolution);

            var commandHandler = new CreateResolutionCommandHandler(mockDocumentFactoryProvider.Object);
            var command = new CreateResolutionCommand("ResolutionJury", "12345678");

            // Act
            var result = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(expectedDecanalResolution, result.Data);
            mockDocumentFactoryProvider.Verify(x => x.GetFactory("ResolutionJury"), Times.Once);
            mockDocumentFactory.Verify(x => x.CreateDocument(), Times.Once);
            mockDocument.Verify(x => x.CreatePDF("12345678"), Times.Once);
        }

        [Fact]
        public async Task Handle_InvalidResolutionCode_ReturnsEmptyString()
        {
            // Arrange
            var mockDocumentFactoryProvider = new Mock<IDocumentFactoryProvider>();
            var mockDocumentFactory = new Mock<IDocumentFactory>();
            var mockDocument = new Mock<IDocument>();

            mockDocumentFactoryProvider.Setup(x => x.GetFactory("InvalidCode")).Throws<ArgumentException>();

            var handler = new CreateResolutionCommandHandler(mockDocumentFactoryProvider.Object);
            var command = new CreateResolutionCommand("InvalidCode", "12345678");

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Null(result.Data);
            mockDocumentFactoryProvider.Verify(x => x.GetFactory("InvalidCode"), Times.Once);
        }

        [Fact]
        public async Task Handle_ExceptionDuringDocumentCreation_ReturnsEmptyString()
        {
            // Arrange
            var mockDocumentFactoryProvider = new Mock<IDocumentFactoryProvider>();
            var mockDocumentFactory = new Mock<IDocumentFactory>();

            mockDocumentFactoryProvider.Setup(x => x.GetFactory("ResolutionJury")).Returns(mockDocumentFactory.Object);
            mockDocumentFactory.Setup(x => x.CreateDocument()).Throws(new Exception("Error al crear el documento"));

            var handler = new CreateResolutionCommandHandler(mockDocumentFactoryProvider.Object);
            var command = new CreateResolutionCommand("ResolutionJury", "12345678");

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Null(result.Data);
            mockDocumentFactoryProvider.Verify(x => x.GetFactory("ResolutionJury"), Times.Once);
            mockDocumentFactory.Verify(x => x.CreateDocument(), Times.Once);
        }
    }
}
