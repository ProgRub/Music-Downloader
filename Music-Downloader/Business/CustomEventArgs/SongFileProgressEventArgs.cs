using System;
using Business.DTOs;
using Business.Enums;
using Business.Services;

namespace Business.CustomEventArgs
{
    public class SongFileProgressEventArgs:EventArgs
    {
        public int ThreadId { get; set; }
        public SongFileDTO Song { get; set; }
        public SongFileProgress Progress { get; set; }
        public string Url{get;set;}
    }
}