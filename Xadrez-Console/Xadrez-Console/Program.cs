﻿using System;
using Board;
using Chess;

namespace Xadrez_Console
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        ChessMatch match = new ChessMatch();

        while (!match.EndGame)
        {

          try
          {
            Console.Clear();
            Screen.PrintBoard(match.MatchBoard);
            Console.WriteLine();
            Console.WriteLine($"Turn: {match.Turn}");
            Console.WriteLine($"Waiting for a move: {match.CurrentPlayer}");

            Console.WriteLine();
            Console.Write("Origin: ");
            Position origin = Screen.ReadPiecePosition().ToPosition();
            match.ValidateOriginPosition(origin);

            bool[,] possiblePositions = match.MatchBoard.ValidatePiecePositionUsingObject(origin).VerifyPossibleMoves();

            Console.Clear();
            Screen.PrintBoard(match.MatchBoard, possiblePositions);

            Console.WriteLine();
            Console.Write("Destination: ");
            Position destination = Screen.ReadPiecePosition().ToPosition();
            match.ValidateDestinationPosition(origin, destination);

            match.PeformsAMove(origin, destination);
          }
          catch (BoardException exception)
          {
            Console.WriteLine(exception.Message);
            Console.ReadLine();
          }
        }
      }
      catch (Exception exception)
      {
        Console.WriteLine(exception.Message);
      }
    }
  }
}