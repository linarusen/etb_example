<template>
    <div>
        <form ref="form" @submit.prevent="submit">
            <v-text-field v-model="model.name" :counter="10" label="Name&Surname" type="text" :rules="[
                v => !!v || 'Required',
            ]"></v-text-field>
            <v-text-field v-model="model.email" :counter="7" label="E-mail" type="email" :rules="[
                v => !!v || 'Required',
                v => /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(v) || 'Wrong email format'
            ]"></v-text-field>
            <v-text-field v-model="model.phone" label="Phone" type="number" :rules="[
                v => !!v || 'Required',
            ]"></v-text-field>
            <v-text-field v-model="model.bDay" label="Birthday" type="date" :rules="[
                v => !!v || 'Required',
            ]"></v-text-field>

            <v-btn class="me-4" type="submit"> submit </v-btn>

            <v-btn @click="handleReset"> clear </v-btn>
        </form>
    </div>
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
            name: '',
            email: '',
            phone: '',
            bDay: '',
        } as any
    }),


    created() {
        for (let k in this.value) this.model[k] = this.value[k];
    },

    methods: {
        async submit() {
            if (this.model.id) await api.post('customers', this.model);
            else await api.put('customers/create', {
                ...this.model,
                BDay: this.model.bDay,
            });

            this.$emit('submit');

            if (!this.model.id) this.handleReset();

        },

        handleReset() {
            for (let k in this.model) this.model[k] = '';
        }

    },
}
</script>