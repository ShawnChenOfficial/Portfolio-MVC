var viewers = new Vue({
    el: '#views',
    data: {
        url_new: '/api/NewViewer',
        url_refresh: '/api/GetViewers',
        ViewersTopValue: _global_params.InitialViewers,
        ViewersBottomValue: _global_params.InitialViewers,
        ViewersHideValue: _global_params.InitialViewers,
        ViewersClass: "views-bottom-to-top"
    },
    mounted() {
        axios.get(this.url_new)
            .then(response => (console.log('Welcome to Shawn\'s Website')));
        window.setInterval(this.RefreshViewers, 5000);
    },
    methods: {
        RefreshViewers: function () {
            axios.get(this.url_refresh)
                .then(response => {
                    if (response.data != this.ViewersHideValue) {
                        if (this.ViewersClass = 'views-bottom-to-top') {
                            this.ViewersBottomValue = response.data;
                            this.ViewersClass = 'views-top-to-bottom';
                        }
                        else if (this.ViewersClass = 'views-top-to-bottom') {
                            this.ViewersTopValue = response.data;
                            this.ViewersClass = 'views-bottom-to-top';
                        }
                        this.ViewersHideValue = response.data;
                    }
                })
                .catch(error => {
                    console.log(error);
                    if (response.data != this.ViewersHideValue) {
                        if (this.ViewersClass = 'views-bottom-to-top') {
                            this.ViewersBottomValue = 0;
                            this.ViewersClass = 'views-top-to-bottom';
                        }
                        else if (this.ViewersClass = 'views-top-to-bottom') {
                            this.ViewersTopValue = 0;
                            this.ViewersClass = 'views-bottom-to-top';
                        }
                    }
                })
        }
    }
});