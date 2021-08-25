﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using MovieLand.Application.Interfaces;
using MovieLand.Web.Interfaces;
using MovieLand.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MovieLand.Web.Services
{
    public class MoviePageService : IMoviePageService
    {
        private readonly IMovieService _movieService;
        private readonly IFavoritesService _favoritesService;
        private readonly IMapper _mapper;
        private readonly ILogger<MoviePageService> _logger;

        public MoviePageService(IMovieService movieService, IFavoritesService favoritesService, IMapper mapper, ILogger<MoviePageService> logger)
        {
            _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
            _favoritesService = favoritesService ?? throw new ArgumentNullException(nameof(favoritesService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task<IEnumerable<MovieViewModel>> GetMovies(string movieTitle)
        {
            if (string.IsNullOrWhiteSpace(movieTitle))
            {
                var movies = await _movieService.GetMovieList();
                var mappedMovies = _mapper.Map<IEnumerable<MovieViewModel>>(movies);
                return mappedMovies;
            }

            var moviesByTitle = await _movieService.GetMovieByTitle(movieTitle);
            var mappedByTitle = _mapper.Map<IEnumerable<MovieViewModel>>(moviesByTitle);
            return mappedByTitle;
        }


        public async Task<MovieViewModel> GetMovieById(int movieId)
        {
            var movie = await _movieService.GetMovieById(movieId);
            var mappedMovie = _mapper.Map<MovieViewModel>(movie);
            return mappedMovie;
        }


        public async Task<MovieViewModel> GetMovieBySlug(string slug)
        {
            var movie = await _movieService.GetMovieBySlug(slug);
            var mappedMovie = _mapper.Map<MovieViewModel>(movie);
            return mappedMovie;
        }


        public async Task AddToFavorites(string username, int movieId)
        {
            await _favoritesService.AddItem(username, movieId);
        }
    }
}
