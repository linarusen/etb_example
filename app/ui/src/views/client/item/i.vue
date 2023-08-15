<template>
    <form @submit.prevent="submit">
        <v-text-field v-model="model.userAgent" :counter="10" label="UserAgent"></v-text-field>
        <v-text-field v-model="model.appCodeName" :counter="10" label="appCodeName"></v-text-field>
        <v-text-field v-model="model.appName" :counter="10" label="appName"></v-text-field>
        <v-text-field v-model="model.appVersion" :counter="10" label="appVersion"></v-text-field>


        <v-btn class="me-4" type="submit"> submit </v-btn>

        <v-btn @click="handleReset"> clear </v-btn>
    </form>
</template>
<script setup lang="ts">

</script>

<script lang="ts">
import api from '@/store/api/i'
export default {
    props: {
        value: {
            default: () => ({} as any)
        }
    },
    data: () => ({
        model: {
            userAgent:'',
            appCodeName:'',
            appName: '',
            appVersion: '',
        } as any
    }),


    created() {
        for (let k in this.value) this.model[k] = this.value[k];
    },

    methods: {
        async submit() {
            if (this.model.id) await api.post('client', this.model);
            else await api.put('client', this.model);

            this.$emit('submit');
            await new Promise(rk => setTimeout(() => rk(1), 1000))
            this.$emit('submit');

            if (!this.model.id) this.handleReset();

        },

        handleReset() {
            for (let k in this.model) this.model[k] = '';
        }

    },
}
</script>