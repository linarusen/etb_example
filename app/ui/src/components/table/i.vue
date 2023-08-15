<template>
    <v-card>
        <v-card-title>
            <center> {{ module }}</center>
            <v-spacer></v-spacer>
            <v-text-field v-model="search" append-inner-icon="mdi-magnify" label="Search" variant="outlined" single-line
                hide-details>
                <template v-slot:prepend>

                    <slot name="add"></slot>
                </template>
            </v-text-field>
        </v-card-title>
        <v-data-table show-expand :headers="headers" :items="items" :search="search">
            <template v-slot:item.action="item">
                <slot name="action" v-bind:item="item.item"></slot>
            </template>
            <template v-slot:expanded-row="item">
                <slot name="expanded-row" v-bind:item="item.item"></slot>

            </template>
        </v-data-table>
    </v-card>
</template>

<script lang="ts">
import api from '@/store/api/i';
export default {
    props: {
        module: {
            default: () => (''),
        },
        headers: {
            default: () => ([]),
        }
    },
    data() {
        return {
            search: '',
            items: [

            ] as any,
        }
    },

    created() {
        this.init();
    },

    methods: {
        async init() {
            this.items = await api.get(this.module + '/list');

        }
    }
}
</script>