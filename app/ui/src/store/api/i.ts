export default {
    async get(url: string) {
        return await this.fetch(url);
    },
    async post(url: string, data: any) {
        return await this.fetch(url, data, 'post');
    },
    async put(url: string, data: any) {
        return await this.fetch(url, data, 'put');
    },
    async delete(url: string, data: any = null) {
        return await this.fetch(url, data, 'delete');
    },

    hostUrl: 'https://ubiquitous-memory-jgvvxqgr9xxcqv9w-5198.app.github.dev/',//from env proccess.env.api_customer_url
    async fetch(url: string, data: any = null, method: string = 'get') {
        return await fetch(this.hostUrl + url, {
            headers: {
                'content-type': 'application/json',
            },

            method: method,
            body: data ? JSON.stringify(data) : null,
        })
            .then(t => t.json())

    }
}